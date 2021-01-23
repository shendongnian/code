    int index = 0; //class level index
    public static void RunActorEvent(object sender, ElapsedEventArgs e, List<Cast> list)
    {
        int personId = list.ElementAt(index++); //or list[index++]
        _actors.Add(_api.GetPersonInfo(personId));
    }
