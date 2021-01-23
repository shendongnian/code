               foreach (var iMeter in meter)
                  {
                       if (!ip.Contains(iMeter.IP))
                        {
                              ip.Add(iMeter.IP);
                          }
                  }
