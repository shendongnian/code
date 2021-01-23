	public class ContentButton : ContentView
	{
		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ContentButton), null, BindingMode.Default);
		public static readonly BindableProperty CommandParameterProperty =
	BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ContentButton));
		/// <summary>
		/// Occurs when the Button is clicked.
		/// </summary>
		public event EventHandler Clicked;
		/// <summary>
		/// Occurs when the Button is pressed.
		/// </summary>
		public event EventHandler Pressed;
		/// <summary>
		/// Occurs when the Button is released.
		/// <para>The released event always occur before the clicked event.</para>
		/// </summary>
		public event EventHandler Released;
		/// <summary>
		/// Occurs when the style of the button should be changed to let the user know that the button has been pressed.
		/// <para>If the argument is true, it means that the Button was just pressed.
		/// <para>If the argument is false, it means that the Button was just released or that the user has moved his finger out of the buttons boundaries.</para>
		/// </summary>
		public event EventHandler<bool> VisuallyPressedChanged;
		/// <summary>
		/// Gets or sets the command to invoke when the button is activated. This is a bindable property.
		/// </summary>
		public ICommand Command
		{
			get => (ICommand)GetValue(CommandProperty);
			set => SetValue(CommandProperty, value);
		}
		/// <summary>
		/// Gets or sets the parameter to pass to the Command property. This is a bindable property.
		/// </summary>
		public object CommandParameter
		{
			get => GetValue(CommandParameterProperty);
			set => SetValue(CommandParameterProperty, value);
		}
		private bool isVisuallyPressed;
		public ContentButton()
		{
			var touchEffect = new TouchEffect
			{
				Capture = true
			};
			touchEffect.TouchAction += TouchEffect_TouchAction;
			Effects.Add(touchEffect);
		}
		protected override void OnChildAdded(Element child)
		{
			base.OnChildAdded(child);
			// so that the touch events are ignored and bypassed to this control
			if(child is VisualElement visualChild) {
				visualChild.InputTransparent = true;
			}
		}
		private void TouchEffect_TouchAction(object sender, TouchActionEventArgs e)
		{
			// only track the first touch
			if(e.Id != 0) {
				return;
			}
			if(e.Type == TouchActionType.Pressed) {
				Pressed?.Invoke(this, EventArgs.Empty);
				isVisuallyPressed = true;
				VisuallyPressedChanged?.Invoke(this, true);
				return;
			}
			if(e.Type == TouchActionType.Released) {
				if(isVisuallyPressed) {
					Released?.Invoke(this, EventArgs.Empty);
					Clicked?.Invoke(this, EventArgs.Empty);
					if(Command!=null && Command.CanExecute(CommandParameter)) {
						Command.Execute(CommandParameter);
					}
					isVisuallyPressed = false;
					VisuallyPressedChanged?.Invoke(this, false);
				}
				return;
			}
			if(e.Type == TouchActionType.Moved) {
                bool isInside = e.Location.X >= 0 && e.Location.Y >= 0 && e.Location.X <= Bounds.Width && e.Location.Y <= Bounds.Height;
				if(!isInside) {
					if(isVisuallyPressed) {
						isVisuallyPressed = false;
						VisuallyPressedChanged?.Invoke(this, false);
					}
				}
			}
		}
	}
