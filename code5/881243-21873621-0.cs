    <Application x:Class="TeslaFrame.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:metro="http://schemas.codeplex.com/elysium"
             >
     <Application.Resources>      
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/Elysium;component/Themes/Generic.xaml"/>
                <ResourceDictionary>
                    <BooleanToVisibilityConverter x:Key="globalBoolToVisConverter" />                 
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
     </Application.Resources>
    </Application>
