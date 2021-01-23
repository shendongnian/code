    dynamic response = Newtonsoft.Json.Linq.JObject.Parse(json);
    var jsonNewHero = "{'hero':{'STR':10,'HP':33,'HT':35,'attackSkill': 13,'defenseSkill':3}}";
    dynamic newHero = Newtonsoft.Json.Linq.JObject.Parse(jsonNewHero);
    response.hero = newHero.hero;
    var newJson = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
