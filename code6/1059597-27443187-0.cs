         try
                            {                                
                                Xread.MoveToAttribute("name");
                                newFont.name = Xread.Value.ToString();
                            }
                            catch { newFont.name = "default"; }
                                           
                            try
                            {
                                Xread.MoveToAttribute("size");
                                newFont.size = int.Parse(Xread.Value.ToString());
                            }
                            catch { newFont.size = 12; }
                            try
                            {
                                 Xread.MoveToAttribute("color");
                                 colorCreator nColor = new colorCreator(Xread.Value);
                                                newFont.ColorR = nColor.R;
                                                newFont.ColorG = nColor.G;
                                                newFont.ColorB = nColor.B;
                                                newFont.ColorA = nColor.A;
                                            }
                                            catch {
                                                newFont.ColorR = 0;
                                                newFont.ColorG = 0;
                                                newFont.ColorB = 0;
                                                newFont.ColorA = 255;
                                            }
