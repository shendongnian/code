    public async void GetTeams()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://nflff.azurewebsites.net");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               
                HttpResponseMessage response = await client.GetAsync("api/teams");//not getting past here
               
                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    var deserializedResponse = JsonConvert.DeserializeObject<List<Teams>>(s);
                    foreach (Teams team in deserializedResponse)
                    {
                        teamsListBox.Items.Add(team.ToString());
                    }
                }
                foreach (var team in Teams.TeamsList)
                {
                    teamsListBox.Items.Add(team.ToString());
                }
            }
        }
