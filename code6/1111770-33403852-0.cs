    private static void PlayUnityVideoAd(Callback<bool> onVideoPlayed)
    {
        string adString = PlayerPrefs.GetString ("UnityAds" + adName);
        if (Advertisement.isReady (adString)) {
         Advertisement.Show (adString, new ShowOptions {
                pause = true,
                resultCallback = result => {
                    switch(result)
                    {
                    case (ShowResult.Finished):
                        onVideoPlayed(true);
                        break;
                    case (ShowResult.Failed):
                        onVideoPlayed(false);
                        break;
                    case(ShowResult.Skipped):
                        onVideoPlayed(false);
                        break;
                    }
                }
            });
        }
        onVideoPlayed(false);
    }
