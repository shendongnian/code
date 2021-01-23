    public ViewModel()
            {
                this.TocData = new TOCData
                {
                    Name = "Chapters",
                    Chapters = new ObservableCollection<Chapter>
                    {
                        new Chapter{ Name="Chapter 1", 
                            Elements = new ObservableCollection<ViewModelBase>
                            {
                                new Chapter
                                {
                                    Name = "Introduction", 
                                    Elements = new ObservableCollection<ViewModelBase>
                                    {
                                        new Page(){Label = "Page I"},
                                        new Page(){Label = "Page II"},
                                        new Page(){Label = "Page III"}
                                    }
                                },
                                new Page(){Label = "Page 1"},
                                new Page(){Label = "Page 2"},
                                new Page(){Label = "Page 3"},
                                new Page(){Label = "Page 4"},
                            }},            
                        new Chapter{ Name="Chapter 2", Elements = new ObservableCollection<ViewModelBase>
                            {              
                                new Page(){Label = "Page 5"},
                                new Page(){Label = "Page 6"},
                                new Page(){Label = "Page 7"},
                                new Page(){Label = "Page 8"},
                            }},
                    }
                };
            }
