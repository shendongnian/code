    [DebuggerNonUserCode]
    private void __BuildControlTree(webusercontrol_ascx __ctrl)
    {
      IParserAccessor parserAccessor = (IParserAccessor) __ctrl;
      parserAccessor.AddParsedSubObject((object) new LiteralControl("\r\n<div class=\"customhtml\">\r\n    "));
      Label label = this.__BuildControlLabel1();
      parserAccessor.AddParsedSubObject((object) label);
      parserAccessor.AddParsedSubObject((object) new LiteralControl("\r\n    "));
      Button button = this.__BuildControlButton1();
      parserAccessor.AddParsedSubObject((object) button);
      parserAccessor.AddParsedSubObject((object) new LiteralControl("\r\n</div>\r\n"));
    }
