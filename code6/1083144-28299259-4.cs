        public App()
        {
            Instance = this;
            var button = new Button {
                Text = "Snap!",
                Command = new Command(o => ShouldTakePicture()),
            };
            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        button,
                        image,
                    },
                },
            };
        }
