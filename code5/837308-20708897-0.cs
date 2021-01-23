    ShellTile appTile = ShellTile.ActiveTiles.First();
                            if (appTile != null)
                            {
                                if (IsolatedStorageSettings.ApplicationSettings.Contains("LiveTileCount"))
                                {
                                    int count = (int)IsolatedStorageSettings.ApplicationSettings["LiveTileCount"];
                                    FlipTileData TileData = new FlipTileData()
                                    {
                                        Count = count +1,
                                    };
                                    IsolatedStorageSettings settings2 = IsolatedStorageSettings.ApplicationSettings;
                                    if (!settings2.Contains("LiveTileCount"))
                                    {
                                        settings2.Add("LiveTileCount", TileData.Count);
                                    }
                                    else
                                    {
                                        settings2["LiveTileCount"] = TileData.Count;
                                    };
                                    settings2.Save();
                                }
                                else
                                {
                                    FlipTileData TileData = new FlipTileData()
                                    {
                                        Count = 1,
                                    };
                                    IsolatedStorageSettings settings2 = IsolatedStorageSettings.ApplicationSettings;
                                    if (!settings2.Contains("LiveTileCount"))
                                    {
                                        settings2.Add("LiveTileCount", TileData.Count);
                                    }
                                    else
                                    {
                                        settings2["LiveTileCount"] = TileData.Count;
                                    };
                                    settings2.Save();
                                }
                            }
                            else
                            {
                                NotifyComplete();
                            }
                        }
                        else
                        {
                            NotifyComplete();
                        }
