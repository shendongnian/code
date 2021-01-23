     <DockPanel>
        <ComboBox x:Name="MainSelector" DisplayMemberPath="NameForSelector" />
     </DockPanel>
     public class SelectorSwitchedControl
        {
            public string Name { get; set; }
            public string NameForSelector{ get; set; }
        }
