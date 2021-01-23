    <?xml version="1.0" encoding="utf-8" ?>
    <CodeSnippets  xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    	<CodeSnippet Format="1.0.0">
    		<Header>
    			<Title>Some Constructor</Title>
    			<Shortcut>svc</Shortcut>
    			<Description>my description</Description>
    			<Author>Jason was here</Author>
    			<SnippetTypes>
    				<SnippetType>Expansion</SnippetType>
    			</SnippetTypes>
    		</Header>
    		<Snippet>
    			<Declarations>
                    <Literal>
                        <ID>accessor</ID>
                        <ToolTip>Access modifier</ToolTip>
                        <Default>public</Default>
                    </Literal>
    				<Literal Editable="false">
    					<ID>classname</ID>
    					<ToolTip>Class name</ToolTip>
    					<Function>ClassName()</Function>
    					<Default>ClassNamePlaceholder</Default>
    				</Literal>
                    <Literal Editable="true">
                        <ID>svcA</ID>
                        <ToolTip>Service A</ToolTip>
                        <Default>ServiceA</Default>
                    </Literal>
    				<Literal Editable="true">
                        <ID>svcAvar</ID>
                        <ToolTip>Service A</ToolTip>
                        <Default>serviceA</Default>
                    </Literal>
    				<Literal Editable="true">
                        <ID>svcB</ID>
                        <ToolTip>Service B</ToolTip>
                        <Default>ServiceB</Default>
                    </Literal>
    				<Literal Editable="true">
                        <ID>svcBvar</ID>
                        <ToolTip>Service B</ToolTip>
                        <Default>serviceB</Default>
                    </Literal>
    			</Declarations>
    			<Code Language="csharp"><![CDATA[$svcA$ $svcAvar$;
    	$svcB$ $svcBvar$;
    	
    	$accessor$ $classname$ ($svcA$ serviceA, $svcB$ serviceB)
    	{
    		this.$svcAvar$ = serviceA;
    		this.$svcBvar$ = serviceB
    	}$end$]]>
    			</Code>
    		</Snippet>
    	</CodeSnippet>
    </CodeSnippets>
