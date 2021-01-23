    using ExitGames.Logging;
    using ExitGames.Logging.Log4Net;
    using log4net.Config;
    using Photon.SocketServer;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace sOnline
    {
      public class PhotonServer : ApplicationBase
      {
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();
        #region Overload of ApplicationBase
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new UnityClient(initRequest.Protocol, initRequest.PhotonPeer);
        }
        protected override void Setup()
        {
            var file = new FileInfo(Path.Combine(BinaryPath, "log4net.config"));
            if (file.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
                XmlConfigurator.ConfigureAndWatch(file);
            }
            if (log.IsDebugEnabled)
            {
                log.Debug("Setup done.");
            }
        }
        protected override void TearDown()
        {
        }
        #endregion
      }
    }
