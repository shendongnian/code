    <?xml version="1.0" encoding="utf-8" ?>
    <CodeSnippets  xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
        <CodeSnippet Format="1.0.0">
            <Header>
                <Title>propn</Title>
                <Shortcut>propn</Shortcut>
                <Description>Code snippet for property and backing field in class implementing INotifyPropertyChanged</Description>
                <Author>Brian Schroer, Modified by RLH</Author>
                <SnippetTypes>
                    <SnippetType>Expansion</SnippetType>
                </SnippetTypes>
            </Header>
            <Snippet>
                <Declarations>
                    <Literal>
                        <ID>type</ID>
                        <ToolTip>Property Type</ToolTip>
                        <Default>int</Default>
                    </Literal>
                    <Literal>
                        <ID>variable</ID>
                        <ToolTip>Underlying Variable</ToolTip>
                        <Default>_myProperty</Default>
                    </Literal>
                    <Literal>
                        <ID>property</ID>
                        <ToolTip>Property name</ToolTip>
                        <Default>MyProperty</Default>
                    </Literal>
            <Literal>
              <ID>notifyMethod</ID>
              <ToolTip>name of method to raise PropertyChanged event</ToolTip>
              <Default>NotifyPropertyChanged</Default>
            </Literal>
          </Declarations>
                <Code Language="csharp"><![CDATA[private $type$ $variable$;
        public $type$ $property$
        {
            get { return $variable$;}
            set 
        { 
            if (value != $variable$)
            {
                $variable$ = value;
                PropertyChanged(this, new PropertyChangedEventArgs("$property$"));
            }
        }
        }
        $end$]]>
                </Code>
            </Snippet>
        </CodeSnippet>
    </CodeSnippets>
