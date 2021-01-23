    private void StoryboardReactionBehavior_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (Storyboard != null)
            {
                Storyboard.Begin();
            }
            else if(Command != null)
            { 
              Command.Execute(null);
            }
        }
