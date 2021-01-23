        private async void changeAway( string structureid, string thermostateId)
        {
            using(HttpClient http = new HttpClient())
            {
                string url =   "https://developer-api.nest.com/";
                StringContent content = null;
                if((string)comboBoxDataType.SelectedValue == "Structures")
                {
                    string away = comboBoxDataAway.SelectedValue.ToString();
                    url += "structures/" + structureid + "/?auth=" + _accessToken;
                    content = new StringContent( "{\"away\":\"" + away + "\"}" );
                }
                else
                {
                    if(textBoxPostData.Text == string.Empty )
                    {
                        OutMessage( "data can not be empty" );
                        return;
                    }
                    int data = 0;
                    if(int.TryParse( textBoxPostData.Text, out data ) == false)
                    {
                        OutMessage( "data must be number" );
                        return;                    
                    }
                    url += "devices/thermostats/" + thermostateId + "/?auth=" + _accessToken;
                    content = new StringContent( "{\"target_temperature_high_c\":" + textBoxPostData.Text + "}" );
                }
                HttpResponseMessage rep = await http.PutAsync( new Uri( url ), content );
                if(null != rep)
                {
                    OutMessage( "http.PutAsync2=" + rep.ToString() );
                }
            }
        }
