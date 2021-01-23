    public void serialcek()
    {
            while (!exitThread)
            {
                foreach (ManagementObject currentObject in theSearcher.Get())
                {
                    try
                    {
                        textBox1.Text = currentObject["Size"].ToString() + " " + currentObject["PNPDeviceID"].ToString();
                    }
                    catch (Exception)
                    {
                        // MessageBox.Show("Bişiler oldu bende anlamadım");
                        //exitThread = false;
                    }
                    finally
                    {
                       currentObject.Dispose();
                    }
                }
            }
            Thread.Sleep(100);
            
            if(<condition>) // add your condition here
            {
               serialcek();
            }
        }
