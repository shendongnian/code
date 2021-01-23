    // ANDREAS added this: In some cases we apparently don't get correct width and height until we have tried to read pixels
		// from the buffer.
		void TryDummySnapshot( ) {
			if(!gotAspect) {
				if( webCamTexture.width>16 ) {
					if( Application.platform == RuntimePlatform.IPhonePlayer ) {
						if(verbose)Debug.Log("Already got width height of WebCamTexture.");
					} else { 
						if(verbose)Debug.Log("Already got width height of WebCamTexture. - taking a snapshot no matter what.");
						var tmpImg = new Texture2D( webCamTexture.width, webCamTexture.height, TextureFormat.RGB24, false );
						Color32[] c = webCamTexture.GetPixels32();
						tmpImg.SetPixels32(c);
						tmpImg.Apply();
						Texture2D.Destroy(tmpImg);
					}
					gotAspect = true;
				} else {
					if(verbose)Debug.Log ("Taking dummy snapshot");
					var tmpImg = new Texture2D( webCamTexture.width, webCamTexture.height, TextureFormat.RGB24, false );
					Color32[] c = webCamTexture.GetPixels32();
					tmpImg.SetPixels32(c);
					tmpImg.Apply();
					Texture2D.Destroy(tmpImg);
				}
			}
		}
