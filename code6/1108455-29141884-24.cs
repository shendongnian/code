    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class GCMBootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            MyIntentService.RunIntentInService(context, intent);
            SetResult(Result.Ok, null, null);
        }
    }
