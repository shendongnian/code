		using System.Reflection;
		using Android.Widget;
		using Cirrious.CrossCore.Platform;
		using Cirrious.MvvmCross.Binding.Bindings.Target;
		namespace MyApp.Ext.Target
		{
			public class MyCompoundButtonCheckedTargetBinding
				: MvxAndroidTargetBinding
			{
				private ICommand _command;
				private IDisposable _canExecuteSubscription;
				private readonly EventHandler<EventArgs> _canExecuteEventHandler;
				protected CompoundButton View
				{
					get { return (CompoundButton)Target; }
				}
				public MyCompoundButtonCheckedTargetBinding(View view)
					: base(target, targetPropertyInfo)
				{
					_canExecuteEventHandler = new EventHandler<EventArgs>(OnCanExecuteChanged);
					SubscribeToEvents();
				}
				public override MvxBindingMode DefaultMode
				{
					get { return MvxBindingMode.OneWay; }
				}
				public override Type TargetType
				{
					get { return typeof(ICommand); }
				}
				public override void SubscribeToEvents()
				{
					var compoundButton = View;
					if (compoundButton == null)
					{
						MvxBindingTrace.Trace(MvxTraceLevel.Error,
											  "Error - compoundButton is null in MvxCompoundButtonCheckedTargetBinding");
						return;
					}
					_subscribed = true;
					compoundButton.CheckedChange += CompoundButtonOnCheckedChange;
				}
				private void RefreshEnabledState()
				{
					var view = View;
					if (view == null)
						return;
					var value = view.Checked;
					
					var shouldBeEnabled = false;
					if (_command != null)
					{
						shouldBeEnabled = _command.CanExecute(value);
					}
					view.Enabled = shouldBeEnabled;
				}
				private void OnCanExecuteChanged(object sender, EventArgs e)
				{
					RefreshEnabledState();
				}
				protected override void SetValueImpl(object target, object value)
				{
					if (_canExecuteSubscription != null)
					{
						_canExecuteSubscription.Dispose();
						_canExecuteSubscription = null;
					}
					_command = value as ICommand;
					if (_command != null)
					{
						_canExecuteSubscription = _command.WeakSubscribe(_canExecuteEventHandler);
					}
					RefreshEnabledState();
				}
				
				private void CompoundButtonOnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs args)
				{
					if (_command == null)
						return;
					var value = args.IsChecked; /* TODO - check this name... */
					
					if (!_command.CanExecute(value))
						return;
					_command.Execute(value);
				}
				protected override void Dispose(bool isDisposing)
				{
					if (isDisposing)
					{
						var view = View;
						if (view != null)
						{
							view.CheckedChange -= CompoundButtonOnCheckedChange;
						}
						if (_canExecuteSubscription != null)
						{
							_canExecuteSubscription.Dispose();
							_canExecuteSubscription = null;
						}                
					}
					base.Dispose(isDisposing);
				}
			}
		}
