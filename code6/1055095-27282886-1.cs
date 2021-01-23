    public string DogJson(string dogname) 
    {
        using (var db = new MyDataContext())
        {
            var dog = Dog.Get(dogname, db);
            var dogDTO = new Dog { name = dog.name, ownerid = dog.ownerid };
            return JsonConvert.SerializeObject(dogDTO);
        }
    }
