		// wave signature for no sound
		byte[] arr = new byte[] { 82, 73, 70, 70, 36, 0, 0, 0, 87, 65, 86, 69, 102, 109, 116, 32, 16, 0, 0, 0, 1, 0, 2, 0, 68, 172, 0, 0, 16, 177, 2, 0, 4, 0, 16, 0, 100, 97, 116, 97, 0, 0, 0, 0};
		using (MemoryStream ms = new MemoryStream()) {
			ms.Write(arr);
			ms.Position = 0;
			using (SoundPlayer p = new SoundPlayer(ms)) {
				p.Play();
			}
		}
