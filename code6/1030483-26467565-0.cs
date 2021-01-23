		MediaPlayer mediaPlayer;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			var videoView = (VideoView)FindViewById<VideoView> (Resource.Id.videoView);
		
			ISurfaceHolder holder = videoView.Holder;
			holder.SetType (SurfaceType.PushBuffers);
			holder.AddCallback( this );
			var descriptor = Assets.OpenFd("test.ogv");
			mediaPlayer = new MediaPlayer ();
			mediaPlayer.SetDataSource(descriptor.FileDescriptor, descriptor.StartOffset, descriptor.Length);
			mediaPlayer.Prepare();
			mediaPlayer.Looping = true;
			mediaPlayer.Start();
		}
		public void SurfaceCreated(ISurfaceHolder holder)
		{
			Console.WriteLine("SurfaceCreated");
			mediaPlayer.SetDisplay(holder);
		}
		public void SurfaceDestroyed(ISurfaceHolder holder)
		{
			Console.WriteLine("SurfaceDestroyed");
		}
		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
		{
			Console.WriteLine("SurfaceChanged");
		}
		public void OnPrepared(MediaPlayer player)
		{
		}
	}
