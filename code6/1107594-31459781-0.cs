    {
    "webroot": "wwwroot",
    "version": "1.0.0-*",
    "dependencies": {},
    "commands": {
    "web": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.WebListener --server.urls http://admin.heartlegacylocal.com"  },
    "frameworks": {
    // "dnx451": { },
    "dnxcore50": {
      "dependencies": {
        "System.Runtime": "4.0.10",
        "Microsoft.AspNet.Hosting": "1.0.0-beta4",
        "Microsoft.AspNet.Mvc": "6.0.0-beta4",
        "Microsoft.AspNet.Server.IIS": "1.0.0-beta6-12075",
        "Microsoft.AspNet.Server.WebListener": "1.0.0-beta6-12457",
        "Microsoft.Framework.DependencyInjection": "1.0.0-beta4",
        "Microsoft.Framework.DependencyInjection.Interfaces": "1.0.0-beta5"
       }
     }
    },
    "publishExclude": [
    "node_modules",
    "bower_components",
    "**.xproj",
    "**.user",
    "**.vspscc"
    ],
    "exclude": [
      "wwwroot",
      "node_modules",
      "bower_components"
      ]
    }
