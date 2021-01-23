        public string BigText { get; set; }
        public string SmallText { get; set; }
        public Color BigTextColor{get; set;}
        public bool ArrowUp{get; set;}
        public string SubBigText{get; set;}
        protected override void OnPreRender(object sender, EventArgs e)
        {
            base.OnPreRender(e);
            lblBigText.Text = BigText;
            lblSmallText.Text = SmallText;
            lblBigText.ForeColor = BigTextColor;
            lblSubBigText.ForeColor = BigTextColor;
            lblSubBigText.Text = SubBigText;
            if (ArrowUp)
            {
                imgArrow.ImageUrl = "~/Images/trend-up-arrow.jpg";
            }
            else
            {
                imgArrow.ImageUrl = "~/Images/trend-down-arrow.jpg";
            }
        }
