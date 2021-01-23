                        var assyTransform = Transform.Identity;
                        var beamInst = mainElement as FamilyInstance;
                        if( beamInst != null )
                        {
                            assyTransform = beamInst.GetTransform();
                            assyTransform.Origin = ( assyInstance.Location as LocationPoint ).Point;
                        }
                        if ( !assyInstance.GetTransform()
                            .AlmostEqual( assyTransform ) )
                        {
                            assyInstance.SetTransform( assyTransform );
                            return true;
                        }
