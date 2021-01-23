    protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                ImageSlider(0);
            }
        }
        public void ImageSlider(int i) {
            MultiView1.ActiveViewIndex = i;
        }
        protected void btn_clickNext(object sender, EventArgs e)
        {
            if ((MultiView1.ActiveViewIndex + 1)<4)
            {
             ImageSlider(MultiView1.ActiveViewIndex+1);
            }
            else
            {
                ImageSlider(MultiView1.ActiveViewIndex);
            }
        }
        protected void btn_clickPrev(object sender, EventArgs e)
        {
            if ((MultiView1.ActiveViewIndex - 1)>=0)
            {
                ImageSlider(MultiView1.ActiveViewIndex-1);
            }
            else
            {
                ImageSlider(MultiView1.ActiveViewIndex);
            }
        }
    }
