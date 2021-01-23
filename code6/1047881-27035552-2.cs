    private Command command;
    [XmlIgnore]
    public string Command
    {
        get
        {
          if (command == null)
          {
            command = new Command(TID, Name));
          }
          return command.Name;
        }
    }
