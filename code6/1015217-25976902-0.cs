    public static void TestWebApiPost() {
        var divs = new DivisionCollectionModel {
            Divisions = new DivisionModel[] {
                new DivisionModel {
                    Name = "In Store"
                },
                new DivisionModel {
                    Name = "Online"
                }
            }
        };
        using (var client = new HttpClient()) {
            var content = JsonConvert.SerializeObject(divs);
            var response = client.PostAsync("http://localhost:56814/corporations/1/divisions", 
                    new StringContent(content, Encoding.UTF8, "application/json")).Result;
            Console.WriteLine(response.ToString());
        }
    }
