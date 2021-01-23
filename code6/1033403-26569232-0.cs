    static List<JSONResponse> Parse(string json)
    {
        var responses = new List<JSONResponse>();
        //string)obj[0][0].programCode.Value;
        dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
        for (int i = 0; i < obj.Count; i++)
        {
            //responses[i] = new JSONResponse() {
            var inf = new List<Inf>();
            var numbers = new List<number>();
            for (int j = 0; j < obj[i].Count; j++)
            {
                if (obj[i][j].campaignId != null)
                    inf.Add(new Inf()
                        {
                            campaignId = (int) obj[i][j].campaignId.Value,
                            programCode = obj[i][j].programCode.Value
                        });
                if (obj[i][j].reason != null)
                    numbers.Add(new number()
                        {
                            about = obj[i][j].about.Value,
                            reason = (int)obj[i][j].reason.Value
                        });
            }
            responses.Add(new JSONResponse()
                {
                    number = numbers.ToArray(),
                    inf = inf.ToArray()
                });
        }
        return responses;
    }
