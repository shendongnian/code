		public class TransferControlFixed : TransferControl {
			public static readonly DependencyProperty HeaderFixedProperty = DependencyProperty.Register("HeaderFixed", typeof(object), typeof(TransferControlFixed), new PropertyMetadata(null));
			public object HeaderFixed {
				get {
					return GetValue(HeaderFixedProperty);
				}
				set {
					SetValue(HeaderFixedProperty, value);
				}
			}
			public override void OnApplyTemplate() {
				base.OnApplyTemplate();
				var control = (ContentControl)this.GetTemplateChild("Header");
				control.SetBinding(ContentControl.ContentProperty, new Binding() {
					Path = new PropertyPath("HeaderFixed"),
					Source = this
				});
			}
		}
