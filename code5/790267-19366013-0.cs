    System.UnauthorizedAccessException was unhandled by user code
      HResult=-2147024891
      Message=Invalid cross-thread access.
      Source=System.Windows
      StackTrace:
           at MS.Internal.XcpImports.CheckThread()
           at MS.Internal.XcpImports.GetValue(IManagedPeerBase managedPeer, DependencyProperty property)
           at System.Windows.DependencyObject.GetOldValue(DependencyProperty property, EffectiveValueEntry& oldEntry)
           at System.Windows.DependencyObject.UpdateEffectiveValue(DependencyProperty property, EffectiveValueEntry oldEntry, EffectiveValueEntry& newEntry, ValueOperation operation)
           at System.Windows.DependencyObject.RefreshExpression(DependencyProperty dp)
           at System.Windows.Data.BindingExpression.SendDataToTarget()
           at System.Windows.Data.BindingExpression.SourcePropertyChanged(PropertyPathListener sender, PropertyPathChangedEventArgs args)
           at System.Windows.PropertyPathListener.RaisePropertyPathStepChanged(PropertyPathStep source)
           at System.Windows.PropertyAccessPathStep.RaisePropertyPathStepChanged(PropertyListener source)
           at System.Windows.CLRPropertyListener.SourcePropertyChanged(Object sender, PropertyChangedEventArgs args)
           at System.Windows.Data.WeakPropertyChangedListener.PropertyChangedCallback(Object sender, PropertyChangedEventArgs args)
           at System.ComponentModel.PropertyChangedEventHandler.Invoke(Object sender, PropertyChangedEventArgs e)
           at ITWEMPhone.ViewModel.NotifyPropertyChanged(String propertyName)
           at ITWEMPhone.ViewModel.set_XValue(String value)
           at ITWEMPhone.ViewModel.<>c__DisplayClass1.<_accelerometer_CurrentValueChanged>b__0()
           at ITWEMPhone.SmartDispatcher.Dispatch(Action action)
           at ITWEMPhone.ViewModel._accelerometer_CurrentValueChanged(Object sender, SensorReadingEventArgs`1 e)
           at System.EventHandler`1.Invoke(Object sender, TEventArgs e)
           at Microsoft.Devices.Sensors.SensorBase`1.FireOnReadingChanged(SensorReadingEventArgs`1 sample)
           at Microsoft.Devices.Sensors.SensorBase`1.OnNewReading(Object sender, NativeSensorEventArgs sample)
           at Microsoft.Devices.Sensors.SensorBase`1.<>c__DisplayClass7.<.ctor>b__3(Object sender, NativeSensorEventArgs args)
           at Microsoft.Devices.Sensors.SensorCallback.OnNewReading(IntPtr pNewReading)
      InnerException: 
