    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xamarin.Forms;
    namespace SEEForgeX.Views
    {
    class CarouselView : CarouselPage
    {
        ContentPage image1,image2,image3,image4;
        public CarouselView()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            string btnPrevTitle = "< Prev";
            string btnNextTitle = "Next >";
            Color btnColor = Color.FromRgba(0, 0, 0, 0.5);
            Color btnTextColor = Color.White;
            LayoutOptions btnPosY = LayoutOptions.EndAndExpand;
            LayoutOptions btnPrevPosX = LayoutOptions.StartAndExpand;
            LayoutOptions btnNextPosX = LayoutOptions.EndAndExpand;
            Font buttonFont = Font.SystemFontOfSize(16, FontAttributes.Bold);
            int btnWidth = 100;
            string exitBtnImg = "close.png";
            Button nextBtn1 = new Button
            {
                Text = btnNextTitle,
                BackgroundColor = btnColor,
                TextColor = btnTextColor,
                VerticalOptions = btnPosY,
                HorizontalOptions = btnNextPosX,
                Font = buttonFont,
                WidthRequest = btnWidth
            };
             Button prevBtn2 = new Button
                {
                    Text = btnPrevTitle,
                    BackgroundColor = btnColor,
                    TextColor = btnTextColor,
                    VerticalOptions = btnPosY,
                    HorizontalOptions = btnPrevPosX,
                    Font = buttonFont,
                    WidthRequest = btnWidth
                };
            image1 = new ContentPage 
            {
                BackgroundImage = "slide_01.jpg",
                Content = new StackLayout 
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Padding = 0,
                    Children = { 
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.StartAndExpand,
                            Padding = new Thickness(0,10,10,0),
                            Children = { exitBtn1 }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.EndAndExpand,
                            Padding = 20,
                            Children = { nextBtn1 }
                        }
                    }
                },
            };
            image2 = new ContentPage
            {
                BackgroundImage = "slide_02.jpg",
                Content = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Padding = 0,
                    Children = { 
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.StartAndExpand,
                            Padding = new Thickness(0,10,10,0),
                            Children = { exitBtn2 }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.EndAndExpand,
                            Padding = 20,
                            Children = {prevBtn2, nextBtn2}
                        }
                    }
                },
            };
    //This is the children of the parent view is like adding stacklayout.children.add(foo) but since              my parent class is a CarouselPage I can access Children its children
                Children.Add(image1);
                Children.Add(image2);
        void prevBtn2_Clicked(object sender, EventArgs e)
        {
            this.CurrentPage = image1;
        }
        void nextBtn1_Clicked(object sender, EventArgs e)
        {
            this.CurrentPage = image2;
        }
        private async void exitBtn_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
            await Navigation.PopModalAsync();
        }
