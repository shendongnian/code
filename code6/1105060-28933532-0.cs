    using System.Collections.Generic;
    public class frmPeripheralOptions
    {
        public frmPeripheralOptions(List<PeriphItem> periphSelect)
        {
            this.PeriphSelect = periphSelect;
        }
        public List<PeriphItem> PeriphSelect { get; set; }
    }
    
    public static Main(string[] args)
    {
        var periphList = new List<PeriphItem>();
        var form = new frmPeripheralOptions(periphList);
    }
