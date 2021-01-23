    private async Task<string> GetDisplayNameAsync(string number)
    {
      Contacts contactsBook = new Contacts();
      var matches = await contactsBook.SearchTaskAsync(number, FilterKind.PhoneNumber);
      ...
      return name;
    }
