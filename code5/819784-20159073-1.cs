    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var rnd = new Random();
            var vm = new VM();
            this.DataContext = vm;
            //enum "A"
            foreach (var a in Enum.GetNames(typeof(A)))
            {
                var vma = new VMA();
                vma.Title = a;
                vm.AItems.Add(vma);
                //enum "B"
                foreach (var b in Enum.GetNames(typeof(B)))
                {
                    var vmb = new VMB();
                    vmb.Title = b;
                    vmb.Value = rnd.Next(1000).ToString();
                    vma.BItems.Add(vmb);
                }
            }
        }
    }
