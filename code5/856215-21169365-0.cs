    <Application
        ...
        xmlns:lib="clr-namespace:YourApp.LibClassProj;assembly=YourApp.LibClassProj">
    
        <Application.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                   ...
                </ResourceDictionary.MergedDictionaries>
                
                <lib:LocalizedStrings x:Key="LocalizedStrings"/>
            </ResourceDictionary>
        </Application.Resources>
    </Application>
