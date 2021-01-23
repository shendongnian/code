        for(i=0;i<ListBoxEffects.count;i++)
        {
         ListBoxItem item = ListBoxEffects.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
         StackPanel TargetStackPanel = common.FindFirstElementInVisualTree<StackPanel>(item);
         TextBlock TargetTextBlock= TargetStackPanel.Children[1] as TextBlock;
         TargetTextBlock.Visibility = Visibility.Visible;
         ListBoxEffects.UpdateLayout();
        }
