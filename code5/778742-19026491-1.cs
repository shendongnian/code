    var devices = new List<Device> {
                    new Device {
                        Software = "Windows",
                        Sensors = new List<Sens> {
                            new Sens {
                                Name = "Sensor1",
                                Channels = new List<Channel> {
                                    new Channel { Id = 1 },
                                    new Channel { Id = 2 }
                                }
                            },
                            new Sens {
                                Name = "Sensor2",
                                Channels = new List<Channel> {
                                    new Channel { Id = 5 }
                                }
                            }
                        }
                    }
                };
