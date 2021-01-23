    xmlns:mmppf="using:Microsoft.PlayerFramework"
    xmlns:smmedia="using:SM.Media.MediaPlayer"
     <mmppf:MediaPlayer IsFullScreenVisible="True" IsFullScreenEnabled="True" IsFullScreen="False"  CurrentStateChanged="mPlayer_CurrentStateChanged" x:Name="mPlayer" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" IsFastForwardEnabled="False" IsInfoEnabled="False" IsLive="True" IsMoreEnabled="False" IsRewindEnabled="False" IsRightTapEnabled="False" IsScrubbingEnabled="False" IsSeekEnabled="False" IsSkipBackEnabled="False" IsSkipAheadEnabled="False" IsReplayEnabled="False" IsTimelineVisible="False" IsTimeElapsedVisible="False" IsTimeRemainingVisible="False" RequestedTheme="Dark">
                <mmppf:MediaPlayer.Plugins>
                    <smmedia:StreamingMediaPlugin />
                </mmppf:MediaPlayer.Plugins>
          
            </mmppf:MediaPlayer>
