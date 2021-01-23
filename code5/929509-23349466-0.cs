    DispatcherTimer dispatcherTimer = new DispatcherTimer();
            private void Page_Loaded(object sender, RoutedEventArgs e)
            {
                dispatcherTimer.Tick += new EventHandler<object>(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                
                int QuestionCount = AppConfiguration.QuestionList.allsecs.Split('-').Length;
                QuestionTimes = new int[QuestionCount];
                for (int i = 0; i < QuestionTimes.Length; i++)
                {
                    if (AppConfiguration.QuestionList.allsecs.Split('-')[i] != null && AppConfiguration.QuestionList.allsecs.Split('-')[i] != "")
                    {
                        QuestionTimes[i] = Convert.ToInt32(AppConfiguration.QuestionList.allsecs.Split('-')[i]);
                    }
                }
    
                string QuestionVideoLink = AppConfiguration.QuestionList.VideoLink;
                VideoPlayer.Source = new Uri(AppConfiguration.TestVideoLink + QuestionVideoLink, UriKind.Absolute);
            }
    
            static bool flag = false;
    
    private void dispatcherTimer_Tick(object sender, object e)
            {
                count++;
                tbMessage.Text = count.ToString();
                
                    //tbMessage.Text = DateTime.Now.Second.ToString();
                    //tbMessage.Text = mp.Position.Seconds.ToString() + " " + dispatcherTimer.Interval.Seconds.ToString();
                    if (sn.Contains(mp.Position.Seconds) && !flag)
                    {
                        mp.Pause();
                        dispatcherTimer.Stop();
                        tbDenemeSoru.Text = "Deneme Soru 1";
                        tbMessage.Text = "Video Durdu";
                        pnlProgressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                        count = 0;
                    }
                    if (sn.Contains(mp.Position.Seconds) && !flag)
                    {
                        mp.Pause();
                        dispatcherTimer.Stop();
                        tbDenemeSoru.Text = "Deneme Soru 2";
                        tbMessage.Text = "Video Durdu";
                        pnlProgressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                        count = 0;
                    }
    
                    if (mp.Position.Seconds > 3 && count == 0)
                    {
                        flag = true;
                    }
    
                
                // Updating the Label which displays the current second
                
                // Forcing the CommandManager to raise the RequerySuggested event
                //CommandManager.InvalidateRequerySuggested();
            }
    
            private void btnOk_Click(object sender, RoutedEventArgs e)
            {
                pnlProgressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                mp.Play();
                dispatcherTimer.Start();
                flag = false;
            }
