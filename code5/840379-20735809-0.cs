    using System;
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls.Primitives;
    
    namespace Caliburn.Micro
    {
        public class WindowManager
        {    
            public virtual void ShowPopup(object rootModel, object context = null, IDictionary<string, object> settings = null)
            {
                var popup = CreatePopup(rootModel, settings);
                var view = ViewLocator.LocateForModel(rootModel, popup, context);
    
                popup.Child = view;
                //popup.SetValue(View.IsGeneratedProperty, true);
    
                ViewModelBinder.Bind(rootModel, popup, null);
                Caliburn.Micro.Action.SetTargetWithoutContext(view, rootModel);
    
                var activatable = rootModel as IActivate;
                if (activatable != null)
                {
                    activatable.Activate();
                }
    
                var deactivator = rootModel as IDeactivate;
                if (deactivator != null)
                {
                    popup.Closed += delegate { deactivator.Deactivate(true); };
                }
    
                popup.IsOpen = true;
                //popup.CaptureMouse();
            }
    
            protected virtual Popup CreatePopup(object rootModel, IDictionary<string, object> settings)
            {
                var popup = new Popup();
    
                ApplySettings(popup, settings);
    
                return popup;
            }
    
            bool ApplySettings(object target, IEnumerable<KeyValuePair<string, object>> settings)
            {
                if (settings != null)
                {
                    var type = target.GetType();
    
                    foreach (var pair in settings)
                    {
                        var propertyInfo = type.GetPropertyCaseInsensitive(pair.Key);
    
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(target, pair.Value, null);
                        }
                    }
    
                    return true;
                }
    
                return false;
            }
        }
    }
