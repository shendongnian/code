        protected override void OnCreate(Bundle bundle)
        {
            .....
            if (this.Intent.Extras.ContainsKey("ResultData"))
            {
                var resultData = this.Intent.Extras.Get("ResultData");
            }
        }
