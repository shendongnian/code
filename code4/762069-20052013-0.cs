    try
            {
                MbnInterfaceManager mbnInfMgr = new MbnInterfaceManager();
                IMbnInterfaceManager mbnInfMgrInterface = mbnInfMgr as IMbnInterfaceManager;
                if (mbnInfMgrInterface != null)
                {
                    IMbnInterface[] mobileInterfaces = mbnInfMgrInterface.GetInterfaces() as IMbnInterface[];
                    if (mobileInterfaces != null && mobileInterfaces.Length > 0)
                    {
                        try
                        {
                            MBN_READY_STATE readyState = mobileInterfaces[0].GetReadyState();
                            switch (readyState)
                            {
                                case MBN_READY_STATE.MBN_READY_STATE_BAD_SIM:
                                    MessageBox.Show("The SIM is invalid (PIN Unblock Key retrials have exceeded the limit).");
                                    break;
                                case MBN_READY_STATE.MBN_READY_STATE_DEVICE_BLOCKED:
                                    MessageBox.Show("The device is blocked by a PIN or password which is preventing the device from initializing and registering onto the network.");
                                    break;
                                case MBN_READY_STATE.MBN_READY_STATE_DEVICE_LOCKED:
                                    MessageBox.Show("The device is locked by a PIN or password which is preventing the device from initializing and registering onto the network.");
                                    break;
                                case MBN_READY_STATE.MBN_READY_STATE_FAILURE:
                                    MessageBox.Show("General device failure.");
                                    break;
                                case MBN_READY_STATE.MBN_READY_STATE_INITIALIZED:
                                    try
                                    {
                                        IMbnSubscriberInformation subInfo = mobileInterfaces[0].GetSubscriberInformation();
                                        if (subInfo != null)
                                        {
                                            SIMNumber = subInfo.SimIccID;
                                        }
                                        else
                                        {
                                            SIMNumber = "Unable to read SIM info";
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        SIMNumber = "Unable to read SIM info";
                                    }
                                    IMbnRegistration registration = mobileInterfaces[0] as IMbnRegistration;
                                    if (registration != null)
                                    {
                                        try
                                        {
                                            MBN_REGISTER_STATE regState = registration.GetRegisterState();
                                            switch (regState)
                                            {
                                                case MBN_REGISTER_STATE.MBN_REGISTER_STATE_DENIED:
                                                    // SIM Inactive
                                                    simInactive = true;
                                                    MessageBox.Show("The device was denied registration. The most likely cause of this error is an Inactive SIM.");
                                                    break;
                                                case MBN_REGISTER_STATE.MBN_REGISTER_STATE_DEREGISTERED:
                                                    // Do nothing - this is returned before the device has tried to register
                                                    break;
                                                case MBN_REGISTER_STATE.MBN_REGISTER_STATE_HOME:
                                                    // Do nothing
                                                    break;
                                                case MBN_REGISTER_STATE.MBN_REGISTER_STATE_NONE:
                                                    MessageBox.Show("The device registration state is unknown. This state may be set upon failure of registration mode change requests.");
                                                    break;
                                                case MBN_REGISTER_STATE.MBN_REGISTER_STATE_PARTNER:
                                                    // Do nothing
                                                    break;
                                                case MBN_REGISTER_STATE.MBN_REGISTER_STATE_ROAMING:
                                                    // Do nothing
                                                    break;
                                                case MBN_REGISTER_STATE.MBN_REGISTER_STATE_SEARCHING:
                                                    // Do nothing
                                                    break;
                                                default:
                                                    MessageBox.Show("GetRegisterState returned an unexpected state: " + regState.ToString());
                                                    break;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("GetRegisterState Error: " + ex.Message);
                                        }
                                    }
                                    break;
                                case MBN_READY_STATE.MBN_READY_STATE_NOT_ACTIVATED:
                                    MessageBox.Show("The subscription is not activated.");
                                    break;
                                case MBN_READY_STATE.MBN_READY_STATE_OFF:
                                    MessageBox.Show("The mobile broadband device stack is off.");
                                    break;
                                case MBN_READY_STATE.MBN_READY_STATE_SIM_NOT_INSERTED:
                                    MessageBox.Show("The SIM is not inserted.");
                                    break;
                                default:
                                    MessageBox.Show("GetReadyState returned an unexpected state: " + readyState.ToString());
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GetReadyState Error: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No mobileInterfaces found.");
                    }
                }
                else
                {
                    MessageBox.Show("mbnInfMgrInterface is null.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
