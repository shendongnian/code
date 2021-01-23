    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets
      xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <Title>fprop</Title>
          <Shortcut>fprop</Shortcut>
          <Description>Full Property with Backing Store</Description>
          <Author>Nathan McGinn</Author>
          <SnippetTypes>
            <SnippetType>Refactoring</SnippetType>
          </SnippetTypes>
        </Header>
        <Snippet>
          <Declarations>
            <Literal>
              <ID>type</ID>
              <Default>string</Default>
              <ToolTip>The type of your property</ToolTip>
            </Literal>
            <Literal>
              <ID>back</ID>
              <Default>_myProperty</Default>
              <ToolTip>The name of your backing variable</ToolTip>
            </Literal>
            <Literal>
              <ID>prop</ID>
              <Default>MyProperty</Default>
              <ToolTip>Your public property's name</ToolTip>
            </Literal>
          </Declarations>
          <Code Language="CSharp">
            <![CDATA[private $type$ $back$;
            public $type$ $prop$
            {
              get
              {
                return this.$back$;
              }
              set
              {
                this.$back$ = value;
                OnPropertyChanged("$prop$");
              }
            }]]>
          </Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
