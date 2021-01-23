        //Turnstile transition
        public static void UseTurnstileTransition(UIElement element)
        {
            TransitionService.SetNavigationInTransition(element,
                new NavigationInTransition()
                {
                    Backward = new TurnstileTransition()
                    {
                        Mode = TurnstileTransitionMode.BackwardIn
                    },
                    Forward = new TurnstileTransition()
                    {
                        Mode = TurnstileTransitionMode.ForwardIn
                    }
                }
            );
            TransitionService.SetNavigationOutTransition(element,
                new NavigationOutTransition()
                {
                    Backward = new TurnstileTransition()
                    {
                        Mode = TurnstileTransitionMode.BackwardOut
                    },
                    Forward = new TurnstileTransition()
                    {
                        Mode = TurnstileTransitionMode.ForwardOut
                    }
                }
            );
        }
        //Slide transition
        public static void UseSlideTransition(UIElement element)
        {
            TransitionService.SetNavigationInTransition(element,
                new NavigationInTransition()
                {
                    Backward = new SlideTransition()
                    {
                        Mode = SlideTransitionMode.SlideRightFadeIn
                    },
                    Forward = new SlideTransition()
                    {
                        Mode = SlideTransitionMode.SlideLeftFadeIn
                    }
                }
            );
            TransitionService.SetNavigationOutTransition(element,
                new NavigationOutTransition()
                {
                    Backward = new SlideTransition()
                    {
                        Mode = SlideTransitionMode.SlideRightFadeOut
                    },
                    Forward = new SlideTransition()
                    {
                        Mode = SlideTransitionMode.SlideLeftFadeOut
                    }
                }
            );
        }
        //Slide up/down transition
        public static void UseSlideUpDownTransition(UIElement element)
        {
            TransitionService.SetNavigationInTransition(element,
                new NavigationInTransition()
                {
                    Backward = new SlideTransition()
                    {
                        Mode = SlideTransitionMode.SlideUpFadeIn
                    },
                    Forward = new SlideTransition()
                    {
                        Mode = SlideTransitionMode.SlideDownFadeIn
                    }
                }
            );
            TransitionService.SetNavigationOutTransition(element,
                new NavigationOutTransition()
                {
                    Backward = new SlideTransition()
                    {
                        Mode = SlideTransitionMode.SlideUpFadeOut
                    },
                    Forward = new SlideTransition()
                    {
                        Mode = SlideTransitionMode.SlideDownFadeOut
                    }
                }
            );
        }
        //Swivel transition
        public static void UseSwivelTransition(UIElement element)
        {
            TransitionService.SetNavigationInTransition(element,
                new NavigationInTransition()
                {
                    Backward = new SwivelTransition()
                    {
                        Mode = SwivelTransitionMode.BackwardIn
                    },
                    Forward = new SwivelTransition()
                    {
                        Mode = SwivelTransitionMode.ForwardIn
                    }
                }
            );
            TransitionService.SetNavigationOutTransition(element,
                new NavigationOutTransition()
                {
                    Backward = new SwivelTransition()
                    {
                        Mode = SwivelTransitionMode.BackwardOut
                    },
                    Forward = new SwivelTransition()
                    {
                        Mode = SwivelTransitionMode.ForwardOut
                    }
                }
            );
        }
        //Rotate transition
        public static void UseRotateTransition(UIElement element)
        {
            TransitionService.SetNavigationInTransition(element,
                new NavigationInTransition()
                {
                    Backward = new RotateTransition()
                    {
                        Mode = RotateTransitionMode.In90Clockwise
                    },
                    Forward = new RotateTransition()
                    {
                        Mode = RotateTransitionMode.In180Clockwise
                    }
                }
            );
            TransitionService.SetNavigationOutTransition(element,
                new NavigationOutTransition()
                {
                    Backward = new RotateTransition()
                    {
                        Mode = RotateTransitionMode.Out180Counterclockwise
                    },
                    Forward = new RotateTransition()
                    {
                        Mode = RotateTransitionMode.Out90Counterclockwise
                    }
                }
            );
        }
        //Roll transition (doesn't have any modes)
        public static void UseRollTransition(UIElement element)
        {
            TransitionService.SetNavigationInTransition(element,
                new NavigationInTransition()
                {
                    Backward = new RollTransition()
                    {
                        //Mode = RollTransitionMode.In90Clockwise
                    },
                    Forward = new RollTransition()
                    {
                        //Mode = RollTransitionMode.In180Clockwise
                    }
                }
            );
            TransitionService.SetNavigationOutTransition(element,
                new NavigationOutTransition()
                {
                    Backward = new RotateTransition()
                    {
                        //Mode = RotateTransitionMode.Out180Counterclockwise
                    },
                    Forward = new RotateTransition()
                    {
                        //Mode = RotateTransitionMode.Out90Counterclockwise
                    }
                }
            );
        }
