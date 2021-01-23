    BrowserWindow bw = null;
            try
            {
                Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;
                var browser = new BrowserWindow() /*{ TechnologyName = "MSAA" }*/;
                PropertyExpressionCollection f = new PropertyExpressionCollection();
                f.Add("TechnologyName", "MSAA");
                f.Add("ClassName", "IEFrame");
                f.Add("ControlType", "Window");
                browser.SearchProperties.AddRange(f);
                UITestControlCollection coll = browser.FindMatchingControls();
                // get top of browser stack
                foreach (BrowserWindow win in coll)
                {
                    bw = win;
                    break;
                }
                String url = bw.Uri.ToString(); //this is the value you want to save
            }
            catch (Exception e)
            {
                throw new Exception("Exception getting active (top) browser:   - ------" + e.Message);
            }
            finally
            {
                Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.UIThreadOnly;
            }
