    <Application.Resources>
    	<ResourceDictionary>
    		<ResourceDictionary.ThemeDictionaries>
    			<ResourceDictionary x:Key="Default">
    				<ImageBrush x:Key="PageImageBackground" Stretch="Fill" ImageSource="Assets/bgimage.jpg"/>
    				<LinearGradientBrush x:Key="PageBackground" EndPoint="3,3" StartPoint="0,0" MappingMode="Absolute" SpreadMethod="Repeat">
    					<GradientStop Color="#FFDFDFDD" Offset=".5"/>
    					<GradientStop Color="#FFE8E8E6" Offset=".5"/>
    				</LinearGradientBrush>
    			</ResourceDictionary>
    			<ResourceDictionary x:Key="HighContrast">
    				<SolidColorBrush x:Key="PageBackground" Color="{ThemeResource SystemColorWindowColor}" />
    		        <SolidColorBrush x:Key="PageImageBackground" Color="{ThemeResource SystemColorWindowColor}" />
    			</ResourceDictionary>
    		</ResourceDictionary.ThemeDictionaries>
    	</ResourceDictionary>
    </Application.Resources>
