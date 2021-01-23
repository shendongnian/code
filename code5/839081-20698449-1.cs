         public override void OnCreate(args)
         {
              // normal base call and inflate
              // ...
              var set = this.CreateBindingSet<MyView, MyViewModel>();
              set.Bind(this).For(v => v.CurrentPosition).To(vm => vm.SeekPosition);
              set.Apply();
         }
