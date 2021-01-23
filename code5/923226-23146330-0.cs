	[Activity (Label = "ShakeDetection", MainLauncher = true)]
	public class MainActivity : Activity, Android.Hardware.ISensorEventListener
	{
		bool hasUpdated = false;
		DateTime lastUpdate;
		float last_x = 0.0f;
		float last_y = 0.0f;
		float last_z = 0.0f;
		const int ShakeDetectionTimeLapse = 250;
		const double ShakeThreshold = 800;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			// Register this as a listener with the underlying service.
			var sensorManager = GetSystemService (SensorService) as Android.Hardware.SensorManager;
			var sensor = sensorManager.GetDefaultSensor (Android.Hardware.SensorType.Accelerometer);
			sensorManager.RegisterListener(this, sensor, Android.Hardware.SensorDelay.Game);
		}
		#region Android.Hardware.ISensorEventListener implementation
		public void OnAccuracyChanged (Android.Hardware.Sensor sensor, Android.Hardware.SensorStatus accuracy)
		{
		}
		public void OnSensorChanged (Android.Hardware.SensorEvent e)
		{
			if (e.Sensor.Type == Android.Hardware.SensorType.Accelerometer)
			{
				float x = e.Values[0];
				float y = e.Values[1];
				float z = e.Values[2];
				DateTime curTime = System.DateTime.Now;
				if (hasUpdated == false)
				{
					hasUpdated = true;
					lastUpdate = curTime;
					last_x = x;
					last_y = y;
					last_z = z;
				}
				else
				{
					if ((curTime - lastUpdate).TotalMilliseconds > ShakeDetectionTimeLapse) {
						float diffTime = (float)(curTime - lastUpdate).TotalMilliseconds;
						lastUpdate = curTime;
						float total = x + y + z - last_x - last_y - last_z;
						float speed = Math.Abs(total) / diffTime * 10000;
						if (speed > ShakeThreshold) {
							Toast.MakeText(this, "shake detected w/ speed: " + speed, ToastLength.Short).Show();
						}
						last_x = x;
						last_y = y;
						last_z = z;
					}
				}
			}
		}
		#endregion
	}
