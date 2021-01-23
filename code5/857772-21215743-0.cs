    public partial class  MainEdit
    {
    protected System.Windows.Forms.Label editheader_lbl;
    protected System.Windows.Forms.Button cancel_btn;
    protected System.Windows.Forms.Button save_btn
    public MainEdit()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.editheader_lbl.Font = Program.font_l;
            this.save_btn.Font = Program.font_btn;
            this.save_btn.Size = Program.btnSize;
            this.save_btn.Text = Constants.SAVE;
            this.cancel_btn.Font = Program.font_btn;
            this.cancel_btn.Size = Program.btnSize;
            this.cancel_btn.Text = Constants.CANCEL;
        }
    }
