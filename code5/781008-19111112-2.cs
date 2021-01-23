    @using (Html.BeginForm("CallMe", "Call", FormMethod.Post))
    {
    
      var list = Model as IDictionary<int, int>;
       
      for (var index = 0; index < Model.Count; index++)
      {
        <input type="text" name="dictionary[@index].Key" value="@list.Keys.ElementAtindex)" />
        <input type="text" name="dictionary[@index].Value" value="@list.Values.ElementAt(index)" />
      }
    }
    
