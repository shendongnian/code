    <?xml version="1.0" encoding="utf-8"?>
        <CodeSnippets  xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
            <CodeSnippet Format="1.0.0">
                <Header>
                    <Title>Generate Type In New File</Title>
                    <Description>Snippet for generating a type in a new file</Description>
                    <Author>Microsoft Corporation</Author>
                    <SnippetTypes>
                        <SnippetType>Refactoring</SnippetType>
                    </SnippetTypes>
                </Header>
                <Snippet>
                    <Declarations>
                        <Literal Editable="true">
                            <ID>namespace</ID>
                            <Default></Default>
                        </Literal>
                        <Literal Editable="true">
                            <ID>modifiers</ID>
                            <Default></Default>
                        </Literal>
                        <Literal Editable="true">
                            <ID>typekind</ID>
                            <Default>class</Default>
                        </Literal>
                        <Literal Editable="true">
                            <ID>typename</ID>
                            <Default>name</Default>
                        </Literal>
                        <Literal Editable="true">
                            <ID>typebase</ID>
                            <Default></Default>
                        </Literal>
                        <Literal>
                            <ID>linqusing</ID>
                            <Function>CheckMinimumTargetFramework(3.5,
                                using System.Linq;)
                            </Function>
                        </Literal>
                    </Declarations>
                    <Code Language="csharp">
                        <![CDATA[$end$using System;
                            using System.Collections.Generic;$linqusing$
                            using System.Text;
                            namespace $namespace$
                            {
                                $modifiers$ $typekind$ $typename$ $typebase$
                                {
                                }
                            }
                        ]]>
                    </Code>
                </Snippet>
            </CodeSnippet>
        </CodeSnippets>
---
The section of interest for you is this `<Code>` section:
    <Code Language="csharp">
        <![CDATA[$end$using System;using System.Collections.Generic;$linqusing$
            using System.Text;
            namespace $namespace$
            {
                $modifiers$ $typekind$ $typename$ $typebase$
                {
                }
            }
        ]]>
    </Code>
Add your `using xyz.blah.blah.blah` namespace right after the `using System.Text;`, save and the next class you add should be good to go.
---
>Note: This is going to change how classes are added across all projects in Visual Studio, so beware!
