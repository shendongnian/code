        <ContentView.GestureRecognizers>
            <TapGestureRecognizer Tapped="TapGestureRecognizer_OnTapped" Command="{Binding Source={x:Reference ContentButtonView}, Path=Command}" CommandParameter="{Binding Source={x:Reference ContentButtonView}, Path=CommandParameter}"/>
        </ContentView.GestureRecognizers>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ContentButton));
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
