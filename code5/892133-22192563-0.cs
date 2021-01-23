    <Window
        ...
        xmlns:system="clr-namespace:System;assembly=mscorlib" 
        >
        <ComboBox ...>
            <system:Double>15</system:Double>
            ...
        </ComboBox>
        <Rectangle ... Width={Binding SelectedItem ElementName=breite}/>
