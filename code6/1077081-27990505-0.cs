    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using Castle.DynamicProxy;
    namespace CAM.Utility
    {
        public class WindowManagerEx : WindowManager, IWindowManagerEx
        {
            private readonly List<object> _trayIcons;
            public WindowManagerEx()
            {
                _trayIcons = new List<object>();
            }
            public override bool? ShowDialog(object rootModel, object context = null, IDictionary<string, object> settings = null)
            {
                rootModel = rootModel.UnwrapProxy();
                return base.ShowDialog(rootModel, context, settings);
            }
            public override void ShowWindow(object rootModel, object context = null, IDictionary<string, object> settings = null)
            {
                rootModel = rootModel.UnwrapProxy();
           
                base.ShowWindow(rootModel, context, settings);
            }
            public override void ShowPopup(object rootModel, object context = null, IDictionary<string, object> settings = null)
            {
                rootModel = rootModel.UnwrapProxy();
                base.ShowPopup(rootModel, context, settings);
            }
            public bool? ShowDialog<TViewModel>(object context = null, IDictionary<string, object> settings = null)
            {
                var viewModelInstance = IoC.Get<TViewModel>();
                return ShowDialog(viewModelInstance, context, settings);
            }
            public void ShowWindow<TViewModel>(object context = null, IDictionary<string, object> settings = null)
            {
                var viewModelInstance = IoC.Get<TViewModel>();
                ShowWindow(viewModelInstance, context, settings);
            }
            public void ShowPopup<TViewModel>(object context = null, IDictionary<string, object> settings = null)
            {
                var viewModelInstance = IoC.Get<TViewModel>();
                ShowPopup(viewModelInstance, context, settings);
            }
            public void ShowTrayIcon<TViewModel>(object context = null)
            {
                var viewModelInstance = IoC.Get<TViewModel>();
                _trayIcons.Add(viewModelInstance);
            }
            public void Dispose()
            {
                foreach (var trayIcon in _trayIcons)
                {
                    var disposable = trayIcon as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            }
        }
        public static class CastleProxyExtensions
        {
            public static object UnwrapProxy(this object target)
            {
                var proxy = target as IProxyTargetAccessor;
            
                if (proxy != null)
                {
                    dynamic dynamicProxy = proxy;
                    dynamic interceptors = dynamicProxy.__interceptors;
                    dynamic interceptor = interceptors[0];
                    target = interceptor.Instance;
                }
                return target;
            }
        }
    }
