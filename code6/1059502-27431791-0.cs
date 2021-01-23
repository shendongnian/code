    using WMPLib;
    
    using System;
    using System.Diagnostics.CodeAnalysis;
    
    
    namespace Merlinia.CommonClasses
    {
       /// <summary>
       /// This class provides a very simple wrapper layer for the Microsoft Windows Media Player.
       /// 
       /// Remember to call Dispose() when the player is no longer needed. (Actually, this may not be 
       /// necessary.)
       /// </summary>
       public class MMediaPlayer : IDisposable
       {
          #region Private variables
    
          // Reference to an Interop object for the COM object that interfaces with Microsoft Windows 
          //  Media Player
          private readonly WindowsMediaPlayer _windowsMediaPlayer = null;
    
          // Number of repeats left, negative = keep looping
          private int _repeatCount = -1;
    
          // Part of the IDisposable pattern
          private bool _isDisposed = false;
          
          #endregion Private variables
    
    
          #region Constructor
    
          /// <summary>
          /// Constructor.
          /// </summary>
          public MMediaPlayer()
          {
             try
             {
                // Instantiate the Windows Media Player Interop object 
                _windowsMediaPlayer = new WindowsMediaPlayer();
    
                // Hook up a couple of event handlers
                _windowsMediaPlayer.MediaError += WindowsMediaPlayer_MediaError;
                _windowsMediaPlayer.PlayStateChange += WindowsMediaPlayer_PlayStateChange;
             }
             catch (Exception e)
             {
                _cLog.Error(0x3ad3a52u, e);
             }
          }
    
          #endregion Constructor
    
    
          #region Public methods
    
          /// <summary>
          /// Method to start the media player playing a file.
          /// </summary>
          /// <param name="fileName">complete file name</param>
          /// <param name="repeatCount">zero = repeat indefinitely, else number of times to repeat</param>
          public void PlayMediaFile(string fileName, int repeatCount)
          {
             if (_windowsMediaPlayer == null)
                return;
    
             _repeatCount = --repeatCount;  // Zero -> -1, 1 -> zero, etc.
    
             if (_windowsMediaPlayer.playState == WMPPlayState.wmppsPlaying)
                _windowsMediaPlayer.controls.stop();  // Probably unnecessary
    
             _windowsMediaPlayer.URL = fileName;
             _windowsMediaPlayer.controls.play();
          }
    
    
          /// <summary>
          /// Method to stop the media player.
          /// </summary>
          public void StopPlayer()
          {
             if (_windowsMediaPlayer == null)
                return;
    
             _repeatCount = 0;
             _windowsMediaPlayer.controls.stop();
          }
    
          #endregion Public methods
    
    
          #region Private methods
    
          /// <summary>
          /// Event-handler method called by Windows Media Player when the media file can't be opened, 
          /// or some other error. This is logged, but otherwise ignored - the calling module is not 
          /// signaled in any way.
          /// </summary>
          private static void WindowsMediaPlayer_MediaError(object pMediaObject)
          {
             _cLog.Error(0x3ad1d3bu);
          }
    
    
          /// <summary>
          /// Event-handler method called by Windows Media Player when the "state" of the media player 
          /// changes. This is used to repeat the playing of the media for the specified number of 
          /// times, or maybe for an indeterminate number of times.
          /// </summary>
          private void WindowsMediaPlayer_PlayStateChange(int newState)
          {
             if ((WMPPlayState)newState == WMPPlayState.wmppsStopped)
             {
                if (_repeatCount != 0)
                {
                   _repeatCount--;
                   _windowsMediaPlayer.controls.play();
                }
             }
          }
    
          #endregion Private methods
    
    
          #region IDisposable stuff
    
          // This copied from here: http://msdn.microsoft.com/en-us/library/system.idisposable.aspx
    
          /// <summary>
          /// Method to implement IDisposable. Do not make this method virtual - a derived class should 
          /// not be able to override this method.
          /// </summary>
          public void Dispose()
          {
             // Call the following method
             Dispose(true);
    
             // This object will be cleaned up by the Dispose() method below. Therefore, we call 
             //  GC.SuppressFinalize to take this object off the finalization queue and prevent 
             //  finalization code for this object from executing a second time.
             GC.SuppressFinalize(this);
          }
    
    
          /// <summary>
          /// Dispose(bool disposing) executes in two distinct scenarios. If isDisposing equals true, 
          /// the method has been called directly or indirectly by a user's code. Managed and unmanaged 
          /// resources can be disposed. If isDisposing equals false, the method has been called by the 
          /// runtime from inside the finalizer and you should not reference other objects - only 
          /// unmanaged resources can be disposed.
          /// </summary>
          protected virtual void Dispose(bool isDisposing)
          {
             // Check to see if Dispose() has already been called
             if (!_isDisposed)
             {
                // If isDisposing equals true, dispose all managed and unmanaged resources
                if (isDisposing && _windowsMediaPlayer != null)
                {
                   // Close the media player. (This may not be necessary?)
                   _windowsMediaPlayer.close();
                }
    
                // Note disposing has been done
                _isDisposed = true;
             }
          }
    
          #endregion IDisposable stuff
    
       }
    }
