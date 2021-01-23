    private void AnimateEnemy(ContentControl enemy, double from, double to, string propertyToAnimate)
            {
                Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
                DoubleAnimation animation = new DoubleAnimation()
                {
                    From = from,
                    To = to,
                    Duration = new Duration(TimeSpan.FromSeconds(random.Next(4, 6)))
                };
                    Storyboard.SetTarget(animation, enemy);
                    storyboard.SetTargetProperty(animation, propertyToAnimate);
                    storyboard.Children.Add(animation);
                    storyboard.Begin();
                }
