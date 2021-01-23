    public Result Parse(string input)
    {
       using (InitLock.ReadLock())
       {
          return parser.Parse(input);
       }
    }
