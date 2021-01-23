    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace TestAttachedPropertyValidationError
    {
    	class HasErrorUtility
    	{
    		public static readonly DependencyProperty HasErrorProperty = DependencyProperty.RegisterAttached("HasError",
    																		typeof(bool),
    																		typeof(HasErrorUtility),
    																		new FrameworkPropertyMetadata(false,
    																									  FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
    																									  null,
    																									  CoerceHasError));
    
    		public static bool GetHasError(DependencyObject d)
    		{
    			return (bool)d.GetValue(HasErrorProperty);
    		}
    
    		public static void SetHasError(DependencyObject d, bool value)
    		{
    			d.SetValue(HasErrorProperty, value);
    		}
    
    		private static object CoerceHasError(DependencyObject d, Object baseValue)
    		{
    			var ret = (bool)baseValue;
    			if (BindingOperations.IsDataBound(d, HasErrorProperty))
    			{
    				if (GetHasErrorDescriptor(d) == null)
    				{
    					var desc = DependencyPropertyDescriptor.FromProperty(Validation.HasErrorProperty, d.GetType());
    					desc.AddValueChanged(d, OnHasErrorChanged);
    					SetHasErrorDescriptor(d, desc);
    					ret = Validation.GetHasError(d);
    				}
    			}
    			else
    			{
    				if (GetHasErrorDescriptor(d) != null)
    				{
    					var desc = GetHasErrorDescriptor(d);
    					desc.RemoveValueChanged(d, OnHasErrorChanged);
    					SetHasErrorDescriptor(d, null);
    				}
    			}
    
    			return ret;
    		}
    
    		private static readonly DependencyProperty HasErrorDescriptorProperty = DependencyProperty.RegisterAttached("HasErrorDescriptor",
    																				typeof(DependencyPropertyDescriptor),
    																				typeof(HasErrorUtility));
    
    		private static DependencyPropertyDescriptor GetHasErrorDescriptor(DependencyObject d)
    		{
    			var ret = d.GetValue(HasErrorDescriptorProperty);
    			return ret as DependencyPropertyDescriptor;
    		}
    
    		private static void SetHasErrorDescriptor(DependencyObject d, DependencyPropertyDescriptor value)
    		{
    			d.SetValue(HasErrorDescriptorProperty, value);
    		}
    
    		private static void OnHasErrorChanged(object sender, EventArgs e)
    		{
    			var d = sender as DependencyObject;
    
    			if (d != null)
    			{
    				d.SetValue(HasErrorProperty, d.GetValue(Validation.HasErrorProperty));
    			}
    		}
    
    	}
    }
