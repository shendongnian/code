       DeviceList xDeviceList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly); 
                DeviceInstance someDeviceInstance; 
                foreach (DeviceInstance deviceInstance in xDeviceList) 
                { 
                    someDeviceInstance = deviceInstance; 
                    break; 
                } 
     
                Device someDevice = new Device(someDeviceInstance.InstanceGuid); 
                someDevice.SetCooperativeLevel(this.Handle, CooperativeLevelFlags.Exclusive | CooperativeLevelFlags.Background); 
                int[] axis = new int[0]; 
                foreach (DeviceObjectInstance doi in someDevice.Objects) 
                { 
                    if((doi.Flags & (int)ObjectInstanceFlags.Actuator) != 0) 
                    { 
                        axis = new int[axis.Length + 1]; 
                        axis[axis.Length - 1] = doi.Offset; 
                    } 
                } 
     
                someDevice.Acquire(); 
     
                Effect effect = new Effect(); 
                effect.SetDirection(new int[axis.Length]); 
                effect.SetAxes(new int[axis.Length]); 
                effect.ConditionStruct = new Condition[axis.Length]; 
     
                effect.Flags = EffectFlags.Cartesian | EffectFlags.ObjectOffsets; 
                effect.Duration = int.MaxValue; 
                effect.SamplePeriod = 0; 
                effect.Gain = 10000; 
                effect.TriggerButton = (int)Microsoft.DirectX.DirectInput.Button.NoTrigger; 
                effect.TriggerRepeatInterval = 0; 
                effect.UsesEnvelope = false; 
                effect.EffectType = Microsoft.DirectX.DirectInput.EffectType.ConstantForce; 
                effect.StartDelay = 0; 
                effect.Constant = new Microsoft.DirectX.DirectInput.ConstantForce(); 
                effect.Constant.Magnitude = -5000; 
                EffectObject effectObject = null; 
                foreach (EffectInformation ei in someDevice.GetEffects(EffectType.ConstantForce)) 
                { 
                    effectObject = new EffectObject(ei.EffectGuid, effect, someDevice); 
                } 
     
                effectObject.SetParameters(effect, EffectParameterFlags.Start ); 
  
  
