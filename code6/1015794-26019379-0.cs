    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Controls;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Data;
    using xxxx.EFW.Helper;
    
    namespace xxxx.EFW.Behaviors
    {
        public sealed class InputBindingValidation
        {
            public static DependencyProperty ValidateDataErrorsProperty = DependencyProperty.RegisterAttached(
                       "ValidateDataErrors",
                       typeof(bool),
                       typeof(InputBindingValidation),
                       new UIPropertyMetadata(false, OnValidateDataErrors));
            private static void OnValidateDataErrors(DependencyObject target, DependencyPropertyChangedEventArgs e)
            {
                var element = target as TextBox;
                if (GetValidateDataErrors(target))
                    element.Initialized += InitializeDataError;
                else
                    element.Initialized -= InitializeDataError;
            }
            private static void InitializeDataError(object sender, EventArgs e)
            {
                var element = sender as TextBox;
                if (element == null)
                    throw new InvalidOperationException("This behavior can be attached to a TextBox item only.");
                BindingExpression be = element.GetBindingExpression(TextBox.TextProperty);
                if (be != null)
                {
                    Binding bind = new Binding()
                                    {
                                        Path = be.ParentBinding.Path,
                                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                                        Mode = be.ParentBinding.Mode,
                                        Converter = be.ParentBinding.Converter,
                                        ValidatesOnDataErrors = true
                                    };
                    if (be.ParentBinding.Source != null)
                        bind.Source = be.ParentBinding.Source;
                    element.SetBinding(TextBox.TextProperty, bind);
                }
            }
        
            public static void SetValidateDataErrors(DependencyObject d, bool value)
            {
                d.SetValue(ValidateDataErrorsProperty, value);
            }
            public static bool GetValidateDataErrors(DependencyObject d)
            {
                return (bool)d.GetValue(ValidateDataErrorsProperty);
            }
        }
    }
